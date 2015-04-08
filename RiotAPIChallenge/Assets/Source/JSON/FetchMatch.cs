
using UnityEngine;
using System.Collections;

namespace Assets.Source.JSON
{
    class FetchMatch : MonoBehaviour
    {
        void Start()
        {
            JSONUtils.initJsonObjectConversion();

            StartCoroutine( getMatchIDList() );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerator getMatchIDList()
        {
            Fetch fetch = new Fetch(success, failure, RiotAPIConstants.MATCHv2_2(Region.NorthAmerica, 1787569113 ), MatchDetail.fromJSON );
            
            return fetch.WaitForUrlData();
        }

        private void success(object obj)
        {
            if ( obj is MatchDetail )
            {
                MatchDetail matchDetail = obj as MatchDetail;
            } 
        }

        private void failure(string message)
        {
            Debug.LogError(message);
        }
    }
}
