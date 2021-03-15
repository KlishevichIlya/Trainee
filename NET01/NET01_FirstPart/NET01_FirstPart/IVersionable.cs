namespace NET01_FirstPart
{
    public interface IVersionable
    {
        byte[] GetVersion();
        void SetVersion(params byte[] numbers);
    }
}
