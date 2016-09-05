using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.MediaFoundation
{
    partial class Sample
    {
        /// <summary>Gets or sets the sample time.</summary>
        /// <value>The sample time, in 100-nanosecond units.</value>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public long? SampleTime
        {
            get
            {
                long value;
                var result = GetSampleTime(out value);
                if (result == ResultCode.NoSampleTimestamp)
                    return null;
                result.CheckError();
                return value;
            }
            set
            {
                if (!value.HasValue) throw new ArgumentNullException(nameof(value));
                SetSampleTime(value.Value);
            }
        }

        /// <summary>Gets or sets the duration of the sample.</summary>
        /// <value>The duration of the sample, in 100-nanosecond units.</value>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public long? SampleDuration
        {
            get
            {
                long value;
                var result = GetSampleDuration(out value);
                if (result == ResultCode.NoSampleDuration)
                    return null;
                result.CheckError();
                return value;
            }
            set
            {
                if (!value.HasValue) throw new ArgumentNullException(nameof(value));
                SetSampleDuration(value.Value);
            }
        }
    }
}