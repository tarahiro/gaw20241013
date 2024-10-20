namespace gad20241013.Item
{
    /// <summary>
    /// アイテムのデータ一つあたりのマスターです。
    /// </summary>
    public interface IItemMaster
    {
        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>
        string Id { get; }

        string DisplayName { get; }
        string Description { get; }
        string SpritePath { get; }
    }
}
