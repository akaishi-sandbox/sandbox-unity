using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using MagicOnion;

public interface IMyFirstService : IService<IMyFirstService>
{
    Task<UnaryResult<string>> Store(int x, int y);
    Task<UnaryResult<string>> SumLegacyTaskAsync(int x, int y);
    Task<ClientStreamingResult<int, string>> ClientStreamingSampleAsync();
    Task<ServerStreamingResult<string>> ServertSreamingSampleAsync(int x, int y, int z);
    Task<DuplexStreamingResult<int, string>> DuplexStreamingSampleAync();
}

// public class IMyFirstServiceClient : MagicOnionClientBase<IMyFirstService>, IMyFirstService
// {
//     static readonly Method<byte[], byte[]> SumAsyncMethod;
//     static readonly Method<byte[], byte[]> SumAsync2Method;
//     static readonly Method<byte[], byte[]> StreamingOneMethod;
//     static readonly Method<byte[], byte[]> StreamingTwoMethod;
//     static readonly Method<byte[], byte[]> StreamingTwo2Method;
//     static readonly Method<byte[], byte[]> StreamingThreeMethod;

//     static IMyFirstServiceClient()
//     {
//         SumAsyncMethod = new Method<byte[], byte[]>(MethodType.Unary, "IMyFirstService", "SumAsync", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//         SumAsync2Method = new Method<byte[], byte[]>(MethodType.Unary, "IMyFirstService", "SumAsync2", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//         StreamingOneMethod = new Method<byte[], byte[]>(MethodType.ClientStreaming, "IMyFirstService", "StreamingOne", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//         StreamingTwoMethod = new Method<byte[], byte[]>(MethodType.ServerStreaming, "IMyFirstService", "StreamingTwo", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//         StreamingTwo2Method = new Method<byte[], byte[]>(MethodType.ServerStreaming, "IMyFirstService", "StreamingTwo2", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//         StreamingThreeMethod = new Method<byte[], byte[]>(MethodType.DuplexStreaming, "IMyFirstService", "StreamingThree", MagicOnionMarshallers.ThroughMarshaller, MagicOnionMarshallers.ThroughMarshaller);
//     }

//     IMyFirstServiceClient()
//     {
//     }

//     public IMyFirstServiceClient(CallInvoker callInvoker, IFormatterResolver resolver)
//         : base(callInvoker, resolver)
//     {
//     }

//     protected override MagicOnionClientBase<IMyFirstService> Clone()
//     {
//         var clone = new IMyFirstServiceClient();
//         clone.host = this.host;
//         clone.option = this.option;
//         clone.callInvoker = this.callInvoker;
//         clone.resolver = this.resolver;
//         return clone;
//     }

//     public UnaryResult<string> SumAsync(int x, int y)
//     {
//         var __request = LZ4MessagePackSerializer.Serialize(new DynamicArgumentTuple<int, int>(x, y), base.resolver);
//         var __callResult = callInvoker.AsyncUnaryCall(SumAsyncMethod, base.host, base.option, __request);
//         return new UnaryResult<string>(__callResult, base.resolver);
//     }

//     public UnaryResult<string> SumAsync2(int x, int y)
//     {
//         var __request = LZ4MessagePackSerializer.Serialize(new DynamicArgumentTuple<int, int>(x, y), base.resolver);
//         var __callResult = callInvoker.AsyncUnaryCall(SumAsync2Method, base.host, base.option, __request);
//         return new UnaryResult<string>(__callResult, base.resolver);
//     }

//     public ClientStreamingResult<int, string> StreamingOne()
//     {
//         var __callResult = callInvoker.AsyncClientStreamingCall<byte[], byte[]>(StreamingOneMethod, base.host, base.option);
//         return new ClientStreamingResult<int, string>(__callResult, base.resolver);
//     }

//     public ServerStreamingResult<string> StreamingTwo(int x, int y, int z)
//     {
//         var __request = LZ4MessagePackSerializer.Serialize(new DynamicArgumentTuple<int, int, int>(x, y, z), base.resolver);
//         var __callResult = callInvoker.AsyncServerStreamingCall(StreamingTwoMethod, base.host, base.option, __request);
//         return new ServerStreamingResult<string>(__callResult, base.resolver);
//     }

//     public ServerStreamingResult<string> StreamingTwo2(int x, int y, int z = 9999)
//     {
//         var __request = LZ4MessagePackSerializer.Serialize(new DynamicArgumentTuple<int, int, int>(x, y, z), base.resolver);
//         var __callResult = callInvoker.AsyncServerStreamingCall(StreamingTwo2Method, base.host, base.option, __request);
//         return new ServerStreamingResult<string>(__callResult, base.resolver);
//     }

//     public DuplexStreamingResult<int, string> StreamingThree()
//     {
//         var __callResult = callInvoker.AsyncDuplexStreamingCall<byte[], byte[]>(StreamingThreeMethod, base.host, base.option);
//         return new DuplexStreamingResult<int, string>(__callResult, base.resolver);
//     }

// }
