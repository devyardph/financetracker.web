using Microsoft.JSInterop;
using System.ComponentModel;

namespace DYS.FinanceTracker.Shared.Network
{
    public class NetworkStateService : INetworkStateService
    {
        public readonly IJSRuntime _jSRuntime;
        public event Action? StatusChanged;
        public bool IsOnline { get; set; } = true;

        /// <summary>
        /// AUTOMATICALLY CHECK NETWORK STATE
        /// </summary>
        /// <param name="jSRuntime"></param>
        public NetworkStateService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            var reference = DotNetObjectReference.Create(this);
            _jSRuntime.InvokeVoidAsync("network.initialize", reference, "OnStatusChanged");
        }

        [JSInvokable, EditorBrowsable(EditorBrowsableState.Never)]
        public void OnStatusChanged(bool isOnline)
        {
            if (IsOnline != isOnline)
            {
                IsOnline = isOnline;
                StatusChanged?.Invoke();
            }
        }
    }
}
