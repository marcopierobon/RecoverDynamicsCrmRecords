using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using RestoreRecords.Interfaces;

namespace RestoreRecords
{
    class Restore
    {
        private readonly RestoringEntitiesList _restoringEntitiesList = null;
        private readonly CrmConnection _crmConnection = null;

        public Restore(CrmConnection crmConnection, string filePath)
        {
            _restoringEntitiesList = new RestoringEntitiesList();
            IListLoader fileListLoader = new FileListLoader(filePath);
            _restoringEntitiesList.AuditList = fileListLoader.LoadGuidList();
            this._crmConnection = crmConnection;
        }

        public void Execute()
        {
            _restoringEntitiesList.AuditList.AsParallel();
            Parallel.ForEach(_restoringEntitiesList.AuditList, auditId =>
            {
                var request = new RetrieveAuditDetailsRequest {AuditId = auditId};
                var response = (RetrieveAuditDetailsResponse)_crmConnection.Service.Execute(request);
                var attributeAuditDetail = response.AuditDetail as AttributeAuditDetail;
                _crmConnection.Service.Create(attributeAuditDetail.OldValue);

            });



        }
    }
}
