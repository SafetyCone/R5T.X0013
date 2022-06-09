using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0134;


namespace System
{
    public static partial class ISyntaxNodeAnnotationExtensions
    {
        public static AddNodeResult<TParentNode, TMember> AddMemberWithResult<TParentNode, TMember>(this ISyntaxNodeAnnotation<NamespaceDeclarationSyntax> namespaceAnnotation,
            TParentNode parentNode,
            TMember member)
            where TParentNode : SyntaxNode
            where TMember : MemberDeclarationSyntax
        {
            member = member.Annotate(out var memberAnnotation);

            parentNode = namespaceAnnotation.Modify(
                parentNode,
                @namespace => @namespace.AddMembers(member));

            var output = AddNodeResult.From(
                parentNode,
                memberAnnotation);

            return output;
        }
    }
}
