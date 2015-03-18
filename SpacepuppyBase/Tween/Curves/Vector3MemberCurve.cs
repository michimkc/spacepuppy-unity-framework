﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using com.spacepuppy.Utils;

namespace com.spacepuppy.Tween.Curves
{

    [CustomMemberCurve(typeof(Vector3))]
    public class Vector3MemberCurve : MemberCurve
    {

        #region Fields

        private Vector3 _start;
        private Vector3 _end;
        private bool _useSlerp;

        #endregion

        #region CONSTRUCTOR

        protected Vector3MemberCurve()
        {

        }

        public Vector3MemberCurve(float dur, Vector3 start, Vector3 end, bool slerp = false)
            : base(dur)
        {
            _start = start;
            _end = end;
            _useSlerp = slerp;
        }

        public Vector3MemberCurve(Ease ease, float dur, Vector3 start, Vector3 end, bool slerp = false) : base(ease, dur)
        {
            _start = start;
            _end = end;
            _useSlerp = slerp;
        }

        protected override void Init(object start, object end, bool slerp)
        {
            _start = ConvertUtil.ToVector3(start);
            _end = ConvertUtil.ToVector3(end);
            _useSlerp = slerp;
        }

        #endregion

        #region Properties

        public Vector3 Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public Vector3 End
        {
            get { return _end; }
            set { _end = value; }
        }

        public bool UseSlerp
        {
            get { return _useSlerp; }
            set { _useSlerp = value; }
        }

        #endregion

        #region MemberCurve Interface

        protected override object GetValue(float t)
        {
            return (_useSlerp) ? Vector3.Slerp(_start, _end, t) : Vector3.Lerp(_start, _end, t);
        }

        #endregion

    }
}
