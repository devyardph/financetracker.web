namespace DYS.FinanceTracker.Shared.Network
{
    public interface INetworkStateService
    {
        bool IsOnline { get; set; }
        void OnStatusChanged(bool isOnline);
        event Action StatusChanged;
    }
}
