## Introduction

IAttachableRemovable is the base class for [FlatRedBall.Math.AttachableList](/documentation/api/flatredball/math/attachablelist.md "FlatRedBall.Math.AttachableList"). This interface requires that the implementer has a method called RemoveGuaranteedContain.

## Information about RemoveGuaranteedContain

RemoveGuaranteedContain is a method with the following signature:

    void RemoveGuaranteedContain(IAttachable attachable);

RemoveGuaranteedContain is a method which removes the argument attachable from the list and in the case of [FlatRedBall.Math.AttachableList](/documentation/api/flatredball/math/attachablelist.md "FlatRedBall.Math.AttachableList") it cleans up the two-way relationship. For AttachableLists calls Remove, which means that the argument method must be contained in the list (a Contains check is not performed internally). This is why the method includes the phrase "GuaranteedContain".
