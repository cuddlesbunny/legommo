using Ludiq;

namespace Bolt.Enhanced {
  [Descriptor(typeof(BoltLogUnit))]
  public sealed class BoltDebugDescriptor : UnitDescriptor<BoltLogUnit> {
    public BoltDebugDescriptor(BoltLogUnit target) : base(target) { }

    protected override void DefinedPort(IUnitPort port, UnitPortDescription description) {
      base.DefinedPort(port, description);
      description.showLabel = false;
    }
  }
}
