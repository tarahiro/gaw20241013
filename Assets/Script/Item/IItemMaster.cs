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
        int Id { get; }

        string TitleName { get; }
        string GenreName { get; }
        string DescriptionName { get; }
        string IconPath { get; }
        string ScreenShotCenterPath { get; }
        string ScreenShotRightTopPath { get; }
        string ScreenShotRightButtonPath { get; }
    }
}
