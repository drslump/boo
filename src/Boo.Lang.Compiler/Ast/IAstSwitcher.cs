﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, 
// and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// Contact Information
//
// mailto:rbo@acm.org
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by
// astgenerator.boo on 4/26/2004 4:15:34 PM
//

namespace Boo.Lang.Compiler.Ast
{
	using System;
	
	public interface IAstSwitcher
	{
		void OnCompileUnit(CompileUnit node);
		void OnSimpleTypeReference(SimpleTypeReference node);
		void OnArrayTypeReference(ArrayTypeReference node);
		void OnNamespaceDeclaration(NamespaceDeclaration node);
		void OnImport(Import node);
		void OnModule(Module node);
		void OnClassDefinition(ClassDefinition node);
		void OnInterfaceDefinition(InterfaceDefinition node);
		void OnEnumDefinition(EnumDefinition node);
		void OnEnumMember(EnumMember node);
		void OnField(Field node);
		void OnProperty(Property node);
		void OnLocal(Local node);
		void OnMethod(Method node);
		void OnConstructor(Constructor node);
		void OnParameterDeclaration(ParameterDeclaration node);
		void OnDeclaration(Declaration node);
		void OnAttribute(Attribute node);
		void OnStatementModifier(StatementModifier node);
		void OnBlock(Block node);
		void OnDeclarationStatement(DeclarationStatement node);
		void OnAssertStatement(AssertStatement node);
		void OnMacroStatement(MacroStatement node);
		void OnTryStatement(TryStatement node);
		void OnExceptionHandler(ExceptionHandler node);
		void OnIfStatement(IfStatement node);
		void OnUnlessStatement(UnlessStatement node);
		void OnForStatement(ForStatement node);
		void OnWhileStatement(WhileStatement node);
		void OnGivenStatement(GivenStatement node);
		void OnWhenClause(WhenClause node);
		void OnBreakStatement(BreakStatement node);
		void OnContinueStatement(ContinueStatement node);
		void OnRetryStatement(RetryStatement node);
		void OnReturnStatement(ReturnStatement node);
		void OnYieldStatement(YieldStatement node);
		void OnRaiseStatement(RaiseStatement node);
		void OnUnpackStatement(UnpackStatement node);
		void OnExpressionStatement(ExpressionStatement node);
		void OnOmittedExpression(OmittedExpression node);
		void OnExpressionPair(ExpressionPair node);
		void OnMethodInvocationExpression(MethodInvocationExpression node);
		void OnUnaryExpression(UnaryExpression node);
		void OnBinaryExpression(BinaryExpression node);
		void OnReferenceExpression(ReferenceExpression node);
		void OnMemberReferenceExpression(MemberReferenceExpression node);
		void OnStringLiteralExpression(StringLiteralExpression node);
		void OnTimeSpanLiteralExpression(TimeSpanLiteralExpression node);
		void OnIntegerLiteralExpression(IntegerLiteralExpression node);
		void OnDoubleLiteralExpression(DoubleLiteralExpression node);
		void OnNullLiteralExpression(NullLiteralExpression node);
		void OnSelfLiteralExpression(SelfLiteralExpression node);
		void OnSuperLiteralExpression(SuperLiteralExpression node);
		void OnBoolLiteralExpression(BoolLiteralExpression node);
		void OnRELiteralExpression(RELiteralExpression node);
		void OnExpressionInterpolationExpression(ExpressionInterpolationExpression node);
		void OnHashLiteralExpression(HashLiteralExpression node);
		void OnListLiteralExpression(ListLiteralExpression node);
		void OnArrayLiteralExpression(ArrayLiteralExpression node);
		void OnIteratorExpression(IteratorExpression node);
		void OnSlicingExpression(SlicingExpression node);
		void OnAsExpression(AsExpression node);
		void OnCastExpression(CastExpression node);
		void OnTypeofExpression(TypeofExpression node);

	}
}
