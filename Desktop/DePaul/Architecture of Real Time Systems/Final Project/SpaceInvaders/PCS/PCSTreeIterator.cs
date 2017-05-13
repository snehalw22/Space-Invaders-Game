using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PCSTreeIterator
    {

        public static void CalculateIterators(GameObject pRootNode)
        {
            // FIX Todo have this backed into PCSTree

            Debug.Assert(pRootNode != null);
            PCSTreeIterator.pRoot = pRootNode;
            PCSTreeIterator.pWrongParent = (GameObject)pRootNode.pParent;

            PCSTreeIterator.pCurrent = PCSTreeIterator.pRoot;

            GameObject pPrevGameObj = (GameObject)pRootNode;
            // Initialize the reserve pointer
            GameObject pGameObj = (GameObject)pRootNode;


            while (pGameObj != null)
            {
                // fill the basis
                pPrevGameObj = pGameObj;

                // Advance
                pGameObj = PCSTreeIterator.privSecretNext();
                pPrevGameObj.pForward = pGameObj;

                if (pGameObj != null)
                {
                    pGameObj.pReverse = pPrevGameObj;
                }
            }


            //    pRootNode.pForward.pReverse = pRootNode;
            pRootNode.pReverse = pPrevGameObj;

        }

        private static GameObject privSecretNext()
        {
            PCSTreeIterator.pCurrent = privGetNext(PCSTreeIterator.pCurrent);

            return (GameObject)PCSTreeIterator.pCurrent;
        }

        private static GameObject privGetNext(GameObject node, bool UseChild = true)
        {
            GameObject tmp = null;

            Debug.Assert(node != null);

            if ((node.pChild != null) && UseChild)
            {
                tmp = (GameObject)node.pChild;
            }
            else if (node.pSibling != null)
            {
                tmp = (GameObject)node.pSibling;
            }
            else if (node.pParent != PCSTreeIterator.pRoot && node.pParent != PCSTreeIterator.pWrongParent)
            {
                // recurse here
                tmp = PCSTreeIterator.privGetNext((GameObject)node.pParent, false);
            }
            else
            {
                tmp = null;
            }
            return tmp;
        }


        private static GameObject pRoot;
        private static GameObject pCurrent;
        private static GameObject pWrongParent;
    }
}