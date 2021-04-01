using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Bolt.Enhanced {
  public class BuildHelper : IPostprocessBuildWithReport {
    public int callbackOrder => 0;
    public void OnPostprocessBuild(BuildReport report) { }
  }
}
