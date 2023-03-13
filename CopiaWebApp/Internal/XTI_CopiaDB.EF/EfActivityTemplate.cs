using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivityTemplate
{
    private readonly CopiaDbContext db;
    private readonly EfPortfolio portfolio;
    private readonly ActivityTemplateEntity entity;

    internal EfActivityTemplate(CopiaDbContext db, EfPortfolio portfolio, ActivityTemplateEntity entity)
    {
        this.db = db;
        this.portfolio = portfolio;
        this.entity = entity;
    }

    public ActivityTemplateModel ToModel() =>
        new ActivityTemplateModel
        (
            entity.ID,
            entity.TemplateName
        );

    public async Task<EfActivityTemplateField> AddTemplateField(int templateID, ActivityFieldType fieldType)
    {
        var field = new ActivityTemplateFieldEntity
        {
            TemplateID = templateID,
            FieldType = fieldType.Value,
            FieldCaption = fieldType.DisplayText,
            Accessibility = ActivityFieldAccessibility.Values.Editable.Value
        };
        await db.ActivityTemplateFields.Create(field);
        return new EfActivityTemplateField(field);
    }

    public Task<EfActivityTemplateField[]> TemplateFields() =>
        db.ActivityTemplateFields.Retrieve()
            .Where(tf => tf.TemplateID == entity.ID)
            .Select(tf => new EfActivityTemplateField(tf))
            .ToArrayAsync();

    public Task<EfTemplateString> ActivityName() =>
        portfolio.TemplateString(entity.ActivityNameTemplateStringID);

    public async Task<ActivityTemplateDetailModel> ToDetailModel()
    {
        var efActivityTemplateFields = await TemplateFields();
        var efActivityName = await ActivityName();
        var activityNameModel = await efActivityName.ToModel();
        return new ActivityTemplateDetailModel
        (
            ToModel(),
            activityNameModel,
            efActivityTemplateFields.Select(tf => tf.ToModel()).ToArray()
        );
    }
}
