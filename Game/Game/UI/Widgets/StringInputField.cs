// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.StringInputField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public class StringInputField : Field<string>
  {
    public static readonly int kDefaultMultilines = 5;
    public static readonly int kSingleLine = 0;
    private int m_Multiline = StringInputField.kSingleLine;
    private int m_MaxLength;

    public int multiline
    {
      get => this.m_Multiline;
      set
      {
        if (value == this.m_Multiline)
          return;
        this.m_Multiline = value;
        this.SetPropertiesChanged();
      }
    }

    public int maxLength
    {
      get => this.m_MaxLength;
      set
      {
        if (value == this.m_MaxLength)
          return;
        this.m_MaxLength = value;
        this.SetPropertiesChanged();
      }
    }

    public override string GetValue() => base.GetValue() ?? string.Empty;

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("multiline");
      writer.Write(this.m_Multiline);
      writer.PropertyName("maxLength");
      writer.Write(this.m_MaxLength);
    }
  }
}
