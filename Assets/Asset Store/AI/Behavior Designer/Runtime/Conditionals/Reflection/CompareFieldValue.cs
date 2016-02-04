using UnityEngine;
using System;
using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Compares the field value to the value specified. Returns success if the values are the same.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=151")]
    [TaskCategory("Reflection")]
    [TaskIcon("{SkinColor}ReflectionIcon.png")]
    public class CompareFieldValue : Conditional
    {
        [Tooltip("The GameObject to compare the field on")]
        public SharedGameObject targetGameObject;
        [Tooltip("The component to compare the field on")]
        public SharedString componentName;
        [Tooltip("The name of the field")]
        public SharedString fieldName;
        [Tooltip("The value to compare to")]
        public SharedVariable compareValue;

        public override TaskStatus OnUpdate()
        {
            if (compareValue == null) {
                Debug.LogWarning("Unable to compare field - compare value is null");
                return TaskStatus.Failure;
            }

            if (targetGameObject == null || targetGameObject.Value == null) {
                Debug.LogWarning("Unable to compare field");
                return TaskStatus.Failure;
            }

            var type = TaskUtility.GetTypeWithinAssembly(componentName.Value);
            if (type == null) {
                Debug.LogWarning("Unable to compare field - type is null");
                return TaskStatus.Failure;
            }

            var component = targetGameObject.Value.GetComponent(type);
            if (component == null) {
                Debug.LogWarning("Unable to compare the field with component " + componentName.Value);
                return TaskStatus.Failure;
            }

            // If you are receiving a compiler error on the Windows Store platform see this topic:
            // http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=46 
            var field = component.GetType().GetField(fieldName.Value);
            var fieldValue = field.GetValue(component);

            if (fieldValue == null && compareValue.GetValue() == null) {
                return TaskStatus.Success;
            }

            return fieldValue.Equals(compareValue.GetValue()) ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            componentName = null;
            fieldName = null;
            compareValue = null;
        }
    }
}