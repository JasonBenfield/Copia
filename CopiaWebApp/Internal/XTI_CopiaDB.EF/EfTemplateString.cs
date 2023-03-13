using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfTemplateString
{
    private readonly CopiaDbContext db;
    private readonly TemplateStringEntity entity;

    internal EfTemplateString(CopiaDbContext db, TemplateStringEntity entity)
    {
        this.db = db;
        this.entity = entity;
    }

    internal int ID { get => entity.ID; }

    public async Task Edit(bool canEdit, AddTemplateStringPartRequest[] addPartRequests)
    {
        await db.TemplateStrings.Update
        (
            entity,
            ts =>
            {
                ts.CanEdit = canEdit;
            }
        );
        await db.TemplateStringParts.Retrieve()
            .Where(p => p.TemplateStringID == entity.ID)
            .ExecuteDeleteAsync();
        var sequence = 1;
        addPartRequests = addPartRequests
            .Where(p => !p.PartType.Equals(TemplateStringPartType.Values.FixedText) || p.FixedText != "")
            .ToArray();
        foreach (var addPartRequest in addPartRequests)
        {
            var part = new TemplateStringPartEntity
            {
                TemplateStringID = entity.ID,
                Sequence = sequence,
                PartType = addPartRequest.PartType,
                ArrayType = addPartRequest.ArrayType,
                ArrayIndex = addPartRequest.ArrayIndex,
                FieldType = addPartRequest.FieldType,
                FixedText = addPartRequest.FixedText
            };
            await db.TemplateStringParts.Create(part);
            sequence++;
        }
    }

    public async Task<TemplateStringModel> ToModel()
    {
        var parts = await Parts();
        return new TemplateStringModel
        (
            entity.ID,
            entity.CanEdit,
            TemplateStringDataType.Values.Value(entity.DataType),
            parts.Select(p => p.ToModel()).ToArray()
        );
    }

    private Task<EfTemplateStringPart[]> Parts() =>
        db.TemplateStringParts.Retrieve()
            .Where(p => p.TemplateStringID == entity.ID)
            .OrderBy(p => p.Sequence)
            .Select(p => new EfTemplateStringPart(p))
            .ToArrayAsync();
}
