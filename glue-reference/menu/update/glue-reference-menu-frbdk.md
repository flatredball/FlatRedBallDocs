# glue-reference-menu-frbdk

### Introduction

The Update FRBDK option allows you to update the FRBDK and Glue to the daily build on the server. This method will update all tools, so it can be done instead of re-running the FlatRedBall installer. This will not update the libraries used by your game. ![UpdateFrbdk.png](../../../.gitbook/assets/migrated\_media-UpdateFrbdk.png)

### Troubleshooting

#### FRBDK does not update the FRBDK directory

If the Glue Updater does not update the files in your FRBDK directory, you may need to manually edit the permissions on it so that 'Users' and 'Trusted Installer' have 'Modify' permissions to it. 1. Locate your FRBDK directory; the default location being 'C:\Program Files (x86)\FlatRedBall\FRBDK' 2. Right click on it then select 'Properties' from the bottom of the menu. ![FRBDKPerms1new.png](../../../.gitbook/assets/migrated\_media-FRBDKPerms1new.png) 3. Click on the 'Security' tab. ![FRBDKPerms2new.png](../../../.gitbook/assets/migrated\_media-FRBDKPerms2new.png) 4. Then click on 'Edit' ![FRBDKPerms4.png](../../../.gitbook/assets/migrated\_media-FRBDKPerms4.png) 5. Highlight 'Users' and placed a check into the 'Modify' box. ![FRBDKPerms5.png](../../../.gitbook/assets/migrated\_media-FRBDKPerms5.png) 6. Do the same for 'Trusted Installer' then be sure to click on 'Apply' before finally clicking on 'OK'. ![FRBDKPerms6.png](../../../.gitbook/assets/migrated\_media-FRBDKPerms6.png) Now run the update again to see if it works.
