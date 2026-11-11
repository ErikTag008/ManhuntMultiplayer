namespace Project.Assets._Project._Scripts
{
    public class PersistentObjectRegistry
    {
        private Persistent _current;

        public bool TryRegister(Persistent persistent)
        {
            if (_current != null && _current != persistent) return false;

            _current = persistent;
            return true;
        }

        public void Unregister(Persistent persistent)
        {
            if (_current == persistent) _current = null;
        }
    }
}
