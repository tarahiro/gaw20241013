using Tarahiro.MasterData;
using Tarahiro;

namespace gad20241013.Item
{
    /// <summary>
    /// アイテムのデータ一つあたりのマスターです。
    /// </summary>
    public interface IItemMaster : IIdentifiable, IIndexable
    {
        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>

        string DisplayName { get; }
        string Description { get; }
        string SpritePath { get; }
    }
}
