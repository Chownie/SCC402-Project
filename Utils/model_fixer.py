import os
import glob
import zipfile
import tempfile
import shutil
import bpy


def reset_blend():
    for scene in bpy.data.scenes:
        for obj in scene.objects:
            scene.objects.unlink(obj)

    # only worry about data in the startup scene
    for bpy_data_iter in (
            bpy.data.objects,
            bpy.data.meshes,
            bpy.data.lamps,
            bpy.data.cameras):
        for id_data in bpy_data_iter:
            bpy_data_iter.remove(id_data)

currentDir = os.path.join("C:\\", "Users", "Asa", "Documents", "SCC402-Project", "Utils")
os.chdir(currentDir)
for file in glob.glob("*.kmz"):
    reset_blend()
    with tempfile.TemporaryDirectory() as tmpDir:
        suffix = os.path.splitext(file)[0]
        print(suffix)
        os.mkdir(os.path.join(currentDir, suffix))
        bpy.ops.import_scene.sketchup(filepath=file)
        scene = bpy.context.scene
        context = bpy.context

        bpy.context.scene.objects.active = scene.objects.get(suffix)
        current_obj = bpy.context.active_object

        # get the scene
        scene = bpy.context.scene

        # set geometry to origin
        bpy.ops.object.origin_set(type="GEOMETRY_ORIGIN")

        bpy.context.scene.objects.active = scene.objects.get("Model")
        current_obj = bpy.context.active_object

        # set the minimum z coordinate as z for cursor location
        #scene.cursor_location = (0, 0, min(zverts))

        # set the origin to the cursor
        bpy.ops.object.origin_set(type="ORIGIN_CURSOR")

        # set the object to (0,0,0)
        current_obj.location = (0,0,0)

        # reset the cursor
        #scene.cursor_location = (0,0,0)

        bpy.ops.export_scene.fbx(filepath=os.path.join(currentDir, suffix + ".fbx"))