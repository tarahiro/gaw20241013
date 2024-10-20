using gad20241013.Item;
using Tarahiro;
using Tarahiro.Editor.XmlImporter;
using System.Collections.Generic;
using UnityEditor;

namespace Ccc.Editor
{
    internal sealed class ItemImporter
    {
        const string c_XmlPath = "ImportData/Item/Item.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            DisplayName = 2,
            Description = 3,
            SpritePath = 4,

        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import Item", false, 1)]
        static void ImportMenuItem()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"Item imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.ImportWorkbook(c_XmlPath);

            var ItemDataList = new List<ItemMasterData.Record>();

            var sheet = book.TryGetWorksheet(c_SheetName);
            if (sheet == null)
            {
                Log.DebugWarning($"シート: {c_SheetName} が見つかりませんでした。");
            }
            else
            {
                for (int row = 0; row < sheet.Height; ++row)
                {
                    // Indexの欄が有効な数字だったら読み込み
                    if (int.TryParse(sheet[row, (int)Columns.Index].String, out int index))
                    {
                        string id = sheet[row, (int)Columns.Id].String;
                        ItemDataList.Add(new ItemMasterData.Record(index, id)
                        {
                            SettableDisplayName = sheet[row, (int)Columns.DisplayName].String,
                            SettableDescription = sheet[row, (int)Columns.Description].String,
                            SettableSpritePath = sheet[row, (int)Columns.SpritePath].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<ItemMasterData, ItemMasterData.Record, IItemMasterDataRecord>(ItemMasterData.c_DataPath, ItemDataList);
        }
    }
}
