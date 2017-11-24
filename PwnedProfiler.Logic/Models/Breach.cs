﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedProfiler.Logic.Models
{
    /// <summary>
    /// A breach record from the HaveIBeenPwnd API
    /// </summary>
    public class Breach
    {
        /// <summary>
        /// A descriptive title for the breach suitable for displaying to end users. 
        /// It's unique across all breaches but individual values may change in the future (i.e. if another breach occurs against an organisation already in the system). 
        /// If a stable value is required to reference the breach, refer to the "Name" attribute instead. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A Pascal-cased name representing the breach which is unique across all other breaches. 
        /// This value never changes and may be used to name dependent assets (such as images) but should not be shown directly to end users (see the "Title" attribute instead). 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The domain of the primary website the breach occurred on. This may be used for identifying other assets external systems may have for the site. 
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The date (with no time) the breach originally occurred on in ISO 8601 format. 
        /// This is not always accurate — frequently breaches are discovered and reported long after the original incident. 
        /// Use this attribute as a guide only. 
        /// </summary>
        public DateTime BreachedDate { get; set; }

        /// <summary>
        /// The date and time (precision to the minute) the breach was added to the system in ISO 8601 format.  
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// The date and time (precision to the minute) the breach was modified in ISO 8601 format. 
        /// This will only differ from the AddedDate attribute if other attributes represented here are changed or data in the breach itself is changed (i.e. additional data is identified and loaded). 
        /// It is always either equal to or greater then the AddedDate attribute, never less than.  
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        ///  The total number of accounts loaded into the system. 
        /// This is usually less than the total number reported by the media due to duplication or other data integrity issues in the source data. 
        /// </summary>
        public long PwnCount { get; set; }

        /// <summary>
        /// Contains an overview of the breach represented in HTML markup. The description may include markup such as emphasis and strong tags as well as hyperlinks. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fields which were compromised in the breach
        /// </summary>
        public IEnumerable<string> DataClasses { get; set; }

        /// <summary>
        /// Indicates that the breach is considered unverified. 
        /// An unverified breach may not have been hacked from the indicated website. 
        /// An unverified breach is still loaded into HIBP when there's sufficient confidence that a significant portion of the data is legitimate. 
        /// <see href="https://haveibeenpwned.com/FAQs#UnverifiedBreach"/>
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Indicates that the breach is considered fabricated. 
        /// A fabricated breach is unlikely to have been hacked from the indicated website and usually contains a large amount of manufactured data. 
        /// However, it still contains legitimate email addresses and asserts that the account owners were compromised in the alleged breach. 
        /// <see href="https://haveibeenpwned.com/FAQs#FabricatedBreach" />
        /// </summary>
        public bool IsFabricated { get; set; }

        /// <summary>
        /// Indicates if the breach is considered sensitive. The public API will not return any accounts for a breach flagged as sensitive. 
        /// </summary>
        public bool IsSensitive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Indicates if the breach has been retired. 
        /// This data has been permanently removed and will not be returned by the API. 
        /// <see href="https://haveibeenpwned.com/FAQs#RetiredBreach" />
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// Indicates if the breach is considered a spam list. 
        /// This flag has no impact on any other attributes but it means that the data has not come as a result of a security compromise. 
        /// </summary>
        public bool IsSpamList { get; set; }

        /// <summary>
        /// Extension of the logo
        /// </summary>
        public string LogoType { get; set; }
    }
}
