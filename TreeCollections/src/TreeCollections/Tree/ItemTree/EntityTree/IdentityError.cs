﻿using System;

namespace TreeCollections.Tree.ItemTree.EntityTree;

[Flags]
public enum IdentityError
{
    None = 0,
    SiblingIdDuplicate = 0x1,
    SiblingAliasDuplicate = 0x2,
    CyclicIdDuplicate = 0x4,
    TreeScopeIdDuplicate = 0x8
}
    
public static class IdentityErrorExtensions
{
    public static IdentityError Normalize(this IdentityError source)
    {
            var filteredIdVersion = source & ~IdentityError.TreeScopeIdDuplicate & ~IdentityError.SiblingAliasDuplicate;

            return filteredIdVersion == IdentityError.None ? source : filteredIdVersion;
        }
}