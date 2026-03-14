namespace DYS.FinanceTracker.Shared.Security
{
    public class SessionHandler
    {
        private readonly ISupabaseAuthProvider _supabaseAuthProvider;
        private Timer? _timer;

        public SessionHandler(ISupabaseAuthProvider supabaseAuthProvider)
        {
            _supabaseAuthProvider = supabaseAuthProvider;
        }

        public void Start()
        {
            _timer = new Timer(async _ => await _supabaseAuthProvider.RefreshSessionAsync(),
                               null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        }

        public void Stop() => _timer?.Dispose();

    }
}
