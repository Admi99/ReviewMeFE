namespace ReviewMe.Components.Extensions
{
    public static class TaskExtensions
    {
        public static T UseContext<T>(this Task<T> task, Action stateHasChanged) where T : new()
        {
            if (task.IsCompletedSuccessfully)
                return task.Result;

            task.ContinueWith(completedTask =>
            {
                if (completedTask.IsCompletedSuccessfully)
                    stateHasChanged();
            });
            return new T();
        }
    }
}