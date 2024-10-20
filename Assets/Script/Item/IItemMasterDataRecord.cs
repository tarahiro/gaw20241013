using Tarahiro.MasterData;
using Tarahiro;

namespace Item
{
    /// <summary>
    /// 用語集のマスターデータの1件あたりのレコードのインターフェースです。
    /// </summary>
    public interface IItemMasterDataRecord : IIdentifiable, IIndexable
    {
        /// <summary>
        /// マスターデータからGlossary.Modelが使うマスターを生成します。
        /// </summary>
        IItemMaster GetMaster();
    }
}
