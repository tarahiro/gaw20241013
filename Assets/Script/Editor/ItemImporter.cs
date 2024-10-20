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
            Id,
            Title = 3,
            GenreName = 5,
            DescriptionName = 7,
            IconPath = 9,
            ScreenShotCenterPath = 11,
            ScreenShotRightTopPath =13,
            ScreenShotRightButtomPath = 15

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
                            SettableTitleName = sheet[row, (int)Columns.Title].String,
                            SettableGenreName = sheet[row, (int)Columns.GenreName].String,
                            SettableDescriptionName = sheet[row, (int)Columns.DescriptionName].String,
                            SettableIconPath= sheet[row, (int)Columns.IconPath].String,
                            SettableScreenShotCenterPath = sheet[row, (int)Columns.ScreenShotCenterPath].String,
                            SettableScreenShotRightTopPath = sheet[row, (int)Columns.ScreenShotRightTopPath].String,
                            SettableScreenShotRightButtomPath = sheet[row, (int)Columns.ScreenShotRightButtomPath].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<ItemMasterData, ItemMasterData.Record, IItemMasterDataRecord>(ItemMasterData.c_DataPath, ItemDataList);
        }
    }
}
