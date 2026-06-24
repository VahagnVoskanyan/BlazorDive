namespace ServerManagement.StateStore
{
    public class TorontoOnlineServersStore : Observer
    {
        private int _numServersOnline;

        public int GetNumbServersOnline()
        {
            return _numServersOnline;
        }

        public void SetNumberServersOnline(int number)
        {
            _numServersOnline = number;
            BroadcastStateChange();
        }
    }
}
