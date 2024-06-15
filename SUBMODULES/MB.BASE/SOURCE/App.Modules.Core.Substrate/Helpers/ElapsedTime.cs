
namespace App
{
    /// <summary>
    /// A Disposable class to help with logging the durations of operations.
    /// <para>
    /// Of value during the startup stage when tracing how long operations
    /// took, and what can be optimized.
    /// </para>
    /// <para>
    /// Also of use when recording integration operations. Again, useful
    /// for optimisation objectives.
    /// </para>
    /// </summary>
    public class ElapsedTime : IDisposable
    {
        /// <summary>
        /// Start time,
        /// set by Constructor.
        /// </summary>
        public readonly DateTimeOffset Start;

        /// <summary>
        /// Ended time.
        /// </summary>
        public DateTimeOffset? End { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ElapsedTime()
        {
            this.Start = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Sets <see cref="End"/>
        /// </summary>
        public void Stop (){
            this.End = DateTimeOffset.UtcNow;   
        }
        
        /// <summary>
        /// The elapsed time since this class was created.
        /// </summary>
        public TimeSpan Elapsed
        {
            get {
                DateTimeOffset now;
                if (End != null)
                {
                    now = (DateTimeOffset)End;
                }
                else
                {
                    now = DateTimeOffset.UtcNow;
                }
                return now.Subtract(this.Start); 
            }
        }

        

        /// <summary>
        /// Textual representation of the elapsed time.
        /// </summary>
        public string ElapsedText
        {
            get
            {
                TimeSpan elapsed = Elapsed;
                if (elapsed.TotalSeconds < 1)
                {
                    return $"{elapsed.TotalMilliseconds} ms";
                }
                if (elapsed.TotalSeconds < 10)
                {
                    return $"{elapsed.TotalSeconds} secs, {elapsed.Milliseconds} ms";
                }
                if (elapsed.TotalMinutes < 1)
                {
                    return $"{elapsed.TotalSeconds} secs";
                }
                if (elapsed.TotalMinutes < 10)
                {
                    return $"{elapsed.TotalMinutes} mins, {elapsed.TotalSeconds} secs";
                }
                if (elapsed.TotalHours < 1)
                {
                    return $"{elapsed.TotalMinutes} mins";
                }
                return $"{elapsed.TotalHours} hours, {elapsed.TotalMinutes} mins";
            }

        }
        /// <inheritdoc/>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
