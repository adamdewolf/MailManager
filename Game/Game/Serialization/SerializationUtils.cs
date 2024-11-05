// Decompiled with JetBrains decompiler
// Type: Game.Serialization.SerializationUtils
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.AssetPipeline.Native;
using Colossal.Serialization.Entities;
using System;

#nullable disable
namespace Game.Serialization
{
  public static class SerializationUtils
  {
    public static bool IsCompressed(this BufferFormat format)
    {
      return format == BufferFormat.CompressedLZ4 || format == BufferFormat.CompressedZStd;
    }

    public static CompressionFormat BufferToCompressionFormat(BufferFormat format)
    {
      if (format == BufferFormat.CompressedLZ4)
        return CompressionFormat.LZ4;
      if (format == BufferFormat.CompressedZStd)
        return CompressionFormat.ZSTD;
      throw new FormatException(string.Format("Invalid format {0}", (object) format));
    }
  }
}
