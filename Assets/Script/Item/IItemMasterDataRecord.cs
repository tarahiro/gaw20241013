using Tarahiro.MasterData;
using Tarahiro;

namespace gad20241013.Item
{
    /// <summary>
    /// アイテムのマスターデータの1件あたりのレコードのインターフェースです。
    /// </summary>
    public interface IItemMasterDataRecord : IIdentifiable, IIndexable
    {
        /// <summary>
        /// マスターデータからマスターを生成します。
        /// </summary>
        IItemMaster GetMaster();
    }
}
