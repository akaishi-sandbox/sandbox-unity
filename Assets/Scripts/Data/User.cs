// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Data
{

using global::System;
using global::FlatBuffers;

public struct User : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static User GetRootAsUser(ByteBuffer _bb) { return GetRootAsUser(_bb, new User()); }
  public static User GetRootAsUser(ByteBuffer _bb, User obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool UserBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "ABCD"); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public User __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(6); }

  public static Offset<User> CreateUser(FlatBufferBuilder builder,
      int id = 0,
      StringOffset nameOffset = default(StringOffset)) {
    builder.StartObject(2);
    User.AddName(builder, nameOffset);
    User.AddId(builder, id);
    return User.EndUser(builder);
  }

  public static void StartUser(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(1, nameOffset.Value, 0); }
  public static Offset<User> EndUser(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<User>(o);
  }
  public static void FinishUserBuffer(FlatBufferBuilder builder, Offset<User> offset) { builder.Finish(offset.Value, "ABCD"); }
};


}
