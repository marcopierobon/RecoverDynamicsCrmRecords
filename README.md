RecoverDynamicsCrmRecords
=========================

Recover MS Dynamics CRM records from a list of audit Guids


Usage:

Compile and run by passing the two required parameters:

1)The location of the XML file describing the CRM connection. The file needs to have this format:
  <?xml version="1.0" encoding="utf-8" ?>
  <Settings>
    <add key="username" value="" />
    <add key="domain" value="" />
    <add key="password" value="" />
    <add key="organizationUri" value="" />
    <add key="homeRealmUri" value="" />
  </Settings>

2)The location of the file containing a list of Guids, one per line. The file will have this format:
  GUID1(32 alhpanumerical characters)
  GUID2(32 alhpanumerical characters)
