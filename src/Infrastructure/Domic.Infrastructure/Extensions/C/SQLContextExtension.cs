﻿using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Extensions.C;

public static class SQLContextExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public static void Seed(this SQLContext context)
    {
        #region TicketSeeder

        #endregion

        context.SaveChanges();
    }
}