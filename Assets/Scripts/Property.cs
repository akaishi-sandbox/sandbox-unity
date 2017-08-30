using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Property
{

    public long Purchase { get; set; }

    public long NonPurchase { get; set; }

    public long Value
    {
        get
        {
            return Purchase + NonPurchase;
        }
    }

    public static Property operator -(Property p, long l)
    {
        if (p.NonPurchase > 0)
        {
            p.NonPurchase -= l;
            if (p.NonPurchase < 0)
            {
                l = p.NonPurchase * -1;
                p.NonPurchase = 0;
            }
            else
            {
                l = 0;
            }
        }

        if (l > 0)
        {
            p.Purchase -= l;
            if (p.Purchase < 0)
            {
                throw new System.ArithmeticException();
            }
        }

        return p;


    }
}
