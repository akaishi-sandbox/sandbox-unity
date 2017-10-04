public static class DataEx
{
    public static byte[] CreateData(this Data.User user)
    {
        var fb = new FlatBuffers.FlatBufferBuilder(1);
        var name = fb.CreateString(user.Name);
        var u = Data.User.CreateUser(fb, user.Id, name);
        Data.User.FinishUserBuffer(fb, u);

        return fb.SizedByteArray();
    }
}
