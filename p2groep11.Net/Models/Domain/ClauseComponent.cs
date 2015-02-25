using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net
{
    public abstract class ClauseComponent
    {
        void add(ClauseComponent clauseComponent);
        void remove(ClauseComponent clauseComponent);
        ClauseComponent getChild(int i);
        string Name { get; set; }

    }
}
