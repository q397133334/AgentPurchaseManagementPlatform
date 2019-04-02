export const permissionToTree = (parentName, permissions, grantedPermissionNames) => {
  var trees = []
  var list = permissions.filter(p => p.parentName == null || p.parentName == '' || parentName)
  list.forEach(p => {
    var node = {
      title: p.displayName,
      expand: true,
      selected: false,
      checked: grantedPermissionNames.filter(g => g == p.name).length,
      data: p
    }
    node.children = permissionToTree(p.name, permissions.filter(cp => cp.parentName == p.name), grantedPermissionNames)
    trees.push(node)
  })
  return trees
}
