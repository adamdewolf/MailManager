﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.URI
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Text.RegularExpressions;
using Unity.Entities;

#nullable disable
namespace Game.UI
{
  public static class URI
  {
    private static readonly Regex kEntityPattern = new Regex("^entity:\\/\\/(\\d+)\\/(\\d+)$", RegexOptions.Compiled);
    private static readonly Regex kInfoviewPattern = new Regex("^infoview:\\/\\/(\\d+)\\/(\\d+)$", RegexOptions.Compiled);

    public static string FromEntity(Entity entity)
    {
      return string.Format("entity://{0}/{1}", (object) entity.Index, (object) entity.Version);
    }

    public static bool TryParseEntity(string input, out Entity entity)
    {
      Match match = URI.kEntityPattern.Match(input);
      if (match.Success)
      {
        entity = new Entity()
        {
          Index = int.Parse(match.Groups[1].Value),
          Version = int.Parse(match.Groups[2].Value)
        };
        return true;
      }
      entity = Entity.Null;
      return false;
    }

    public static string FromInfoView(Entity entity)
    {
      return string.Format("infoview://{0}/{1}", (object) entity.Index, (object) entity.Version);
    }

    public static bool TryParseInfoview(string input, out Entity entity)
    {
      Match match = URI.kInfoviewPattern.Match(input);
      if (match.Success)
      {
        entity = new Entity()
        {
          Index = int.Parse(match.Groups[1].Value),
          Version = int.Parse(match.Groups[2].Value)
        };
        return true;
      }
      entity = Entity.Null;
      return false;
    }
  }
}