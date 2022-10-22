using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.ViewModel
{
    public class CreateDataViewModel
    {
        public CreateViewModel CreateViewModels { get; set; }
        public List<SipliterListViewModel> SipliterListViewModels { get; set; }
        public List<SokakListViewModel> SokakListViewModels { get; set; }
        public List<DcListViewModel> DcListViewModels { get; set; }
        public List<CoreListViewModel> CoreListViewModels { get; set; }
        public List<TupListViewModel> TupListViewModels { get; set; }
    }
}