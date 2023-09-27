## Introduction

iOS development requires the use of Provisioning Profiles to deploy to iOS hardware, either for development or for final distribution. This section will discuss how to create and use provisioning profiles.

For information on using provisioning profiles, see [this page](http://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/).

## Troubleshooting

The provisioning profile is error prone due to its complexity. If you are unable to get things to work here are some things to try:

### Verify Bundle Identifier

Provisioning profiles are tied to a certain bundle identifier. Verify that the bundle identifier of your app matches the bundle identifier in the provisioning profile.
