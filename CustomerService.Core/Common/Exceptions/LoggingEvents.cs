﻿using Microsoft.Extensions.Logging;

namespace CustomerService.Core.Common.Exceptions
{
    public static class LoggingEvents
    {
        public static readonly EventId InitDatabase =
            new EventId(101, "Error whilst creating and seeding database");
    }
}
