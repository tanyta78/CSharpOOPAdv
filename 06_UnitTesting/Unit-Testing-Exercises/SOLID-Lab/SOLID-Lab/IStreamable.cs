namespace SOLID_Lab
{
    public interface IStreamable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}