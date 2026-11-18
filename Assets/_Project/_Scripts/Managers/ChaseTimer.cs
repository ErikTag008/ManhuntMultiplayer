namespace Project.Assets._Project._Scripts.Managers
{
    // One runner's current chase; it runs from the first contact to the last one
    public struct ChaseTimer
    {
        private double _startTime;
        private double _lastContactTime;
        private bool _isActive;

        public bool IsActive => _isActive;

        // True when a chase just ended because contact was lost for long enough
        public bool Update(bool isInContact, double now, float lostAfterSeconds, out float durationInSeconds)
        {
            durationInSeconds = 0f;
            if (isInContact)
            {
                if (!_isActive) _startTime = now;
                _isActive = true;
                _lastContactTime = now;
                return false;
            }

            if (!_isActive || now - _lastContactTime < lostAfterSeconds) return false;
            return TryEnd(out durationInSeconds);
        }

        public bool TryEnd(out float durationInSeconds)
        {
            durationInSeconds = _isActive ? (float)(_lastContactTime - _startTime) : 0f;
            bool wasActive = _isActive;
            _isActive = false;
            return wasActive;
        }
    }
}
