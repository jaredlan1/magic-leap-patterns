// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2017 Magic Leap, Inc. (COMPANY) All Rights Reserved.
// Magic Leap, Inc. Confidential and Proprietary
//
//  NOTICE:  All information contained herein is, and remains the property
//  of COMPANY. The intellectual and technical concepts contained herein
//  are proprietary to COMPANY and may be covered by U.S. and Foreign
//  Patents, patents in process, and are protected by trade secret or
//  copyright law.  Dissemination of this information or reproduction of
//  this material is strictly forbidden unless prior written permission is
//  obtained from COMPANY.  Access to the source code contained herein is
//  hereby forbidden to anyone except current COMPANY employees, managers
//  or contractors who have executed Confidentiality and Non-disclosure
//  agreements explicitly covering such access.
//
//  The copyright notice above does not evidence any actual or intended
//  publication or disclosure  of  this source code, which includes
//  information that is confidential and/or proprietary, and is a trade
//  secret, of  COMPANY.   ANY REPRODUCTION, MODIFICATION, DISTRIBUTION,
//  PUBLIC  PERFORMANCE, OR PUBLIC DISPLAY OF OR THROUGH USE  OF THIS
//  SOURCE CODE  WITHOUT THE EXPRESS WRITTEN CONSENT OF COMPANY IS
//  STRICTLY PROHIBITED, AND IN VIOLATION OF APPLICABLE LAWS AND
//  INTERNATIONAL TREATIES.  THE RECEIPT OR POSSESSION OF  THIS SOURCE
//  CODE AND/OR RELATED INFORMATION DOES NOT CONVEY OR IMPLY ANY RIGHTS
//  TO REPRODUCE, DISCLOSE OR DISTRIBUTE ITS CONTENTS, OR TO MANUFACTURE,
//  USE, OR SELL ANYTHING THAT IT  MAY DESCRIBE, IN WHOLE OR IN PART.
//
// %COPYRIGHT_END%
// --------------------------------------------------------------------*/
// %BANNER_END%

using UnityEngine;

namespace MagicLeap
{
    /// <summary>
    /// Controller specifically to change _ForegroundColor property
    /// of a material from a gradient palette
    /// </summary>
    public class MaterialForegroundColorController : MaterialController
    {
        #region Private Variables
        [SerializeField, Tooltip("Foreground Color Palette")]
        private Gradient _gradient;
        private float _t = 0;
        #endregion

        #region Unity Methods
        /// <summary>
        /// Validate material
        /// </summary>
        void Start()
        {
            if (!_material.HasProperty("_ForegroundColor"))
            {
                Debug.LogError("Error: MaterialForegroundColorController._material does not have _ForegroundColor (Color), disabling script.");
                enabled = false;
                return;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adjust the foreground color using the gradient
        /// </summary>
        /// <param name="factor">Increment to the index</param>
        public override void OnUpdateValue(float factor)
        {
            _t = Mathf.Repeat(_t + factor, 1.0f);
            Color color = _gradient.Evaluate(_t);
            _material.SetColor("_ForegroundColor", color);
        }
        #endregion
    }
}
