using System.Xml;
using Ludiq;
using UnityEngine;

namespace Bolt.Enhanced {
  [UnitTitle("Bolt Log")]
  [UnitCategory("BoltEnhanced/BoltDebug")]
  [TypeIcon(typeof(Debug))]
  public sealed class BoltLogUnit : Unit {
    [Inspectable]
    [Serialize]
    public BoltLogType logType;

    [DoNotSerialize]
    [PortLabelHidden]
    public ControlInput enter { get; private set; }

    [DoNotSerialize]
    public ValueInput message { get; private set; }

    [DoNotSerialize]
    [PortLabelHidden]
    public ControlOutput exit { get; private set; }

    protected override void Definition() {
      enter = ControlInput(nameof(enter), Enter);
      message = ValueInput<object>(nameof(message));
      exit = ControlOutput(nameof(exit));
      Succession(enter, exit);
      Requirement(message, enter);
    }

    public ControlOutput Enter(Flow flow) {
      GameObject gameObject = flow.stack.self;
      object inputValue = flow.GetValue<object>(message);
      int hashCode = GetHashCode();
      int instanceId = gameObject.GetInstanceID();
      string logMessage = inputValue.ToString();
      BoltLogInfo boltLogInfo = new BoltLogInfo(hashCode, instanceId, logMessage);
      string logMessageJson = JsonUtility.ToJson(boltLogInfo);
      switch (logType) {
        case BoltLogType.Info:
          Debug.Log(logMessageJson);
          break;
        case BoltLogType.Warning:
          Debug.LogWarning(logMessageJson);
          break;
        case BoltLogType.Error:
          Debug.LogError(logMessageJson);
          break;
      }
      return exit;
    }
    
    [System.Serializable]
    class BoltLogInfo {
      public int hashCode;
      public int instanceId;
      public string logMessage;

      public BoltLogInfo(int hashCode, int instanceId, string logMessage) {
        this.hashCode = hashCode;
        this.instanceId = instanceId;
        this.logMessage = logMessage;
      }
    }
  }
}
