using Microsoft.EntityFrameworkCore.Diagnostics;

namespace XTI_CopiaDB;

public sealed class TrackChangesInterceptor : ISaveChangesInterceptor
{
    private readonly HashSet<string> affectedTables = new();

    public IReadOnlyCollection<string> GetAffectedTables() => affectedTables.ToList().AsReadOnly();

    public void SaveChangesFailed(DbContextErrorEventData eventData) { }

    public Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default) => Task.CompletedTask;

    public int SavedChanges(SaveChangesCompletedEventData eventData, int result) => result;

    public ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default) => ValueTask.FromResult(result);

    public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context != null)
        {
            LogAdditions(eventData.Context);
        }
        return result;
    }

    public ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context != null)
        {
            LogAdditions(eventData.Context);
        }
        return ValueTask.FromResult(result);
    }

    private void LogAdditions(DbContext context)
    {
        context.ChangeTracker.DetectChanges();
        foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
        {
            var tableName = entry.Metadata.GetTableName();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                affectedTables.Add(tableName);
            }
        }
    }
}
