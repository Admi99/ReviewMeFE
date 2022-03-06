using Microsoft.JSInterop;

namespace ReviewMe.Frontend
{
    public static class Handlers
    {
        public static Action<string, string, string, int>? NotificationHandler { get; set; }

        [JSInvokable]
        public static void AttachHandlers(IJSObjectReference handlers)
        {
            NotificationHandler = (message, type, title, timeout) =>
                handlers.InvokeVoidAsync("NotificationHandler", message, type, title, timeout);
        }
    }
}