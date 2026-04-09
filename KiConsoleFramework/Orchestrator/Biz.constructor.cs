using KiConsoleFramework.Repo;
using System.Configuration;

namespace KiConsoleFramework.Orchestrator
  {
  public partial class Biz
    {

    public Biz()
      {
      //
      // Compose CourseRepo0 classes -- classes that have no compositional dependencies at all.
      //
      classOneRepo__provisioner = new(() => new ClassOneRepo());
      //
      // Compose CourseRepo1 classes -- classes that have a single compositional dependency.
      //
      // ...
      //
      // Compose CourseRepo2 classes -- classes that have multiple compositional dependencies from CourseRepo0 through CourseRepo1.
      //
      // ...
      // :
      // :
      //
      // Compose CourseRepoN classes -- classes that have multiple compositional dependencies from CourseRepo0 through CourseRepo{N - 1}.
      //
      // ...
      //
      // Compose CourseBiz0 classes -- classes that have no compositional dependencies and don't need the View.
      //
      // ...classX__provisioner = new(() => new());
      //
      // Compose CourseBiz1 classes -- classes that have a single compositional dependency from CourseRepo0 through CourseBiz0 and don't need the View.
      //
      // ...classX__provisioner = new(() => new(classXrepo_imp:classXrepo__provisioner.Value));
      //
      // Compose CourseBiz2 classes -- classes that have multiple compositional dependencies from CourseRepo0 through CourseBiz1 and/or need the View.
      //
      classOne__provisioner = new // one or more dependencies, needs View
        (
        () =>
          {
          var instance = new ClassOneBiz
            (
            appSettings_imp:ConfigurationManager.AppSettings,
            repo_imp:classOneRepo__provisioner.Value
            );
          NotifyObjectBizLoaded(instance);
          return instance;
          }
        );
      // ... classTwo__provisioner = new // multiple dependencies, no need for View
      // ...   (
      // ...   () => new
      // ...     (
      // ...     biz_classOne_imp:classOne__provisioner.Value,
      // ...     repo_imp:classTwoRepo__provisioner.Value
      // ...     )
      // ...   );
      // ... classThree__provisioner = new // no dependencies, needs View
      // ...   (
      // ...   () =>
      // ...     {
      // ...     var instance = new ClassThreeBiz();
      // ...     NotifyObjectBizLoaded(instance);
      // ...     return instance;
      // ...     }
      // ...   );
      // :
      // :
      //
      // Compose CourseBizN classes -- classes that have multiple compositional dependencies from CourseRepo0 through CourseBiz{N - 1} and may need the View.
      //
      // ...
      }

    }
  }
