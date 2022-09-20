import bpy
import os


currPath = os.path.splitext(bpy.data.filepath)[0]+ ".curves.json"
file = open(currPath, "w")  # ////// file stuff /////////////

def countCurves(arr):
  i = 0
  for ob in arr:
    if ob.type == 'CURVE' :
      i+= 1
  return i

curvesCount = countCurves(bpy.data.objects.values())

print("there are %d curves", curvesCount)

file.write('{\n"curves": {\n') # ////// file stuff /////////////
j = 0
for ob in bpy.data.objects.values() : 

  if ob.type == 'CURVE' :
    file.write( '"%s": [' % ob.name) # ////// file stuff /////////////
    for spline in ob.data.splines :
      if len(spline.bezier_points) > 0 :
        file.write("[") # ////// file stuff /////////////
        for bezier_point in spline.bezier_points.values() : 
        
          print("not implemented")
          # handle_left  = ob.matrix_world @ bezier_point.handle_left
          # co           = ob.matrix_world @ bezier_point.co
          # handle_right = ob.matrix_world @ bezier_point.handle_right
          # # ////// file stuff /////////////
          # file.write("[[%.3f, %.3f, %.3f],  " % (handle_left.x, handle_left.y, handle_left.z ))
          # file.write("[%.3f, %.3f, %.3f],  " % (co.x, co.y, co.z ))
          # file.write("[%.3f, %.3f, %.3f]],\n  " % (handle_right.x, handle_right.y, handle_right.z ))
          
      if len(spline.points) > 0:
        i = 0
        for point in spline.points.values() : 
          file.write("\n\t")
          # blender 2.8+ uses @ to multiply MxV. blender 2.8- uses *
          co           = ob.matrix_world @ point.co
        
          # ////// file stuff /////////////
          file.write("[%.3f, %.3f, %.3f]" % (co.x, co.y, co.z ))
          if i < len(spline.points)-1:
            file.write(",")
          i = i + 1
    if j < curvesCount-1:
      file.write("\n],")
    else:
      file.write("\n]")
    j = j + 1
    
    
file.write("}\n}\n")
file.close()
