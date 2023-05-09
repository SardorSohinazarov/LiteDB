using LiteDB;

namespace WebAPIwithLiteDB.LiteDb
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
