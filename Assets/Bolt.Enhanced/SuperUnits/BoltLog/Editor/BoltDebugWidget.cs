using Ludiq;
using UnityEngine;

namespace Bolt.Enhanced {
  [Widget(typeof(BoltLogUnit))]
  public sealed class BoltLogUnitWidget : UnitWidget<BoltLogUnit> {
    public BoltLogUnitWidget(FlowCanvas canvas, BoltLogUnit unit) : base(canvas, unit) { }

    protected override bool showHeaderAddon => true;
    public override bool foregroundRequiresInput => true;
    private BoltLogType lastBoltLogType;

    protected override void DrawHeaderAddon() {
      LudiqGUI.Inspector(metadata["logType"], new Rect(headerAddonPosition.x, headerAddonPosition.y, GetHeaderAddonWidth(), 18), GUIContent.none);
      if (lastBoltLogType != unit.logType) {
        lastBoltLogType = unit.logType;
        Reposition();
        unit.Define();
      }
    }

    protected override float GetHeaderAddonWidth() {
      return 68;
    }

    protected override float GetHeaderAddonHeight(float width) {
      return 20;
    }

    protected override NodeColorMix baseColor {
      get {
        switch (lastBoltLogType) {
          case BoltLogType.Info:
            return NodeColor.Gray;
          case BoltLogType.Warning:
            return NodeColor.Yellow;
          case BoltLogType.Error:
            return NodeColor.Red;
          default:
            return NodeColor.Gray;
        }
      }
    }
  }
}
