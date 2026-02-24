/*----------------------------------------------------------
This Source Code Form is subject to the terms of the
Mozilla Public License, v.2.0. If a copy of the MPL
was not distributed with this file, You can obtain one
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using OneScript.Language.LexicalAnalysis;

namespace OneScript.Language.SyntaxAnalysis.AstNodes
{
    public class WhileLoopNode : BranchingStatementNode
    {
        public WhileLoopNode(Lexem startLexem) : base(NodeKind.WhileLoop, startLexem)
        {
        }

        protected override void OnChildAdded(BslSyntaxNode child)
        {
            if(child is LineMarkerNode)
                base.OnChildAdded(child);
        }
    }
}