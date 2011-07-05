using System;

using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz
{
    /// <summary>
    /// <code>CalendarIntervalScheduleBuilder</code> is a <see cref="IScheduleBuilder" />
    /// that defines calendar time (day, week, month, year) interval-based
    /// schedules for <code>Trigger</code>s.
    /// </summary>
    /// <remarks>
    /// <para>Quartz provides a builder-style API for constructing scheduling-related
    /// entities via a Domain-Specific Language (DSL).  The DSL can best be
    /// utilized through the usage of static imports of the methods on the classes
    /// <code>TriggerBuilder</code>, <code>JobBuilder</code>,
    /// <code>DateBuilder</code>, <code>JobKey</code>, <code>TriggerKey</code>
    /// and the various <code>ScheduleBuilder</code> implementations.</para>
    /// <para>Client code can then use the DSL to write code such as this:</para>
    /// <pre>
    /// JobDetail job = newJob(MyJob.class)
    /// .withIdentity("myJob")
    /// .build();
    /// Trigger trigger = newTrigger()
    /// .withIdentity(triggerKey("myTrigger", "myTriggerGroup"))
    /// .withSchedule(simpleSchedule()
    /// .withIntervalInHours(1)
    /// .repeatForever())
    /// .startAt(futureDate(10, MINUTES))
    /// .build();
    /// scheduler.scheduleJob(job, trigger);
    /// </pre>
    /// </remarks>
    /// <seealso cref="ICalendarIntervalTrigger" />
    /// <seealso cref="CronScheduleBuilder" />
    /// <seealso cref="IScheduleBuilder" />
    /// <seealso cref="SimpleScheduleBuilder" />
    /// <seealso cref="TriggerBuilder" />
    public class CalendarIntervalScheduleBuilder : ScheduleBuilder<ICalendarIntervalTrigger>
    {
        private int interval = 1;
        private IntervalUnit intervalUnit = IntervalUnit.Day;

        private int misfireInstruction = MisfireInstruction.SmartPolicy;

        private CalendarIntervalScheduleBuilder()
        {
        }

        /// <summary>
        /// Create a CalendarIntervalScheduleBuilder.
        /// </summary>
        /// <returns></returns>
        public static CalendarIntervalScheduleBuilder Create()
        {
            return new CalendarIntervalScheduleBuilder();
        }

        /// <summary>
        /// Build the actual Trigger -- NOT intended to be invoked by end users,
        /// but will rather be invoked by a TriggerBuilder which this 
        /// ScheduleBuilder is given to.
        /// </summary>
        /// <returns></returns>
        public override IMutableTrigger Build()
        {
            CalendarIntervalTriggerImpl st = new CalendarIntervalTriggerImpl();
            st.RepeatInterval = interval;
            st.RepeatIntervalUnit = intervalUnit;
            st.MisfireInstruction = misfireInstruction;

            return st;
        }

        /// <summary>
        /// Specify the time unit and interval for the Trigger to be produced.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="interval">the interval at which the trigger should repeat.</param>
        /// <param name="unit"> the time unit (IntervalUnit) of the interval.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithInterval(int interval, IntervalUnit unit)
        {
            ValidateInterval(interval);
            this.interval = interval;
            this.intervalUnit = unit;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.SECOND that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInSeconds">the number of seconds at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInSeconds(int intervalInSeconds)
        {
            ValidateInterval(intervalInSeconds);
            this.interval = intervalInSeconds;
            this.intervalUnit = IntervalUnit.Second;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.MINUTE that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInMinutes">the number of minutes at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInMinutes(int intervalInMinutes)
        {
            ValidateInterval(intervalInMinutes);
            this.interval = intervalInMinutes;
            this.intervalUnit = IntervalUnit.Minute;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.HOUR that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInHours">the number of hours at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInHours(int intervalInHours)
        {
            ValidateInterval(intervalInHours);
            this.interval = intervalInHours;
            this.intervalUnit = IntervalUnit.Hour;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.DAY that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInDays">the number of days at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInDays(int intervalInDays)
        {
            ValidateInterval(intervalInDays);
            this.interval = intervalInDays;
            this.intervalUnit = IntervalUnit.Day;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.WEEK that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInWeeks">the number of weeks at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInWeeks(int intervalInWeeks)
        {
            ValidateInterval(intervalInWeeks);
            this.interval = intervalInWeeks;
            this.intervalUnit = IntervalUnit.Week;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.MONTH that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInMonths">the number of months at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInMonths(int intervalInMonths)
        {
            ValidateInterval(intervalInMonths);
            this.interval = intervalInMonths;
            this.intervalUnit = IntervalUnit.Month;
            return this;
        }

        /// <summary>
        /// Specify an interval in the IntervalUnit.YEAR that the produced
        /// Trigger will repeat at.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="intervalInYears">the number of years at which the trigger should repeat.</param>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="ICalendarIntervalTrigger.RepeatInterval" />
        /// <seealso cref="ICalendarIntervalTrigger.RepeatIntervalUnit" />
        public CalendarIntervalScheduleBuilder WithIntervalInYears(int intervalInYears)
        {
            ValidateInterval(intervalInYears);
            this.interval = intervalInYears;
            this.intervalUnit = IntervalUnit.Year;
            return this;
        }

        /// <summary>
        /// If the Trigger misfires, use the
        /// {@link Trigger#MISFIRE_INSTRUCTION_IGNORE_MISFIRE_POLICY} instruction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>the updated CronScheduleBuilder</returns>
        /// <seealso cref="MisfireInstruction.IgnoreMisfirePolicy" />
        public CalendarIntervalScheduleBuilder WithMisfireHandlingInstructionIgnoreMisfires()
        {
            misfireInstruction = MisfireInstruction.IgnoreMisfirePolicy;
            return this;
        }


        /// <summary>
        /// If the Trigger misfires, use the
        /// <see cref="MisfireInstruction.CalendarIntervalTrigger.DoNothing" /> instruction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="MisfireInstruction.CalendarIntervalTrigger.DoNothing" />
        public CalendarIntervalScheduleBuilder WithMisfireHandlingInstructionDoNothing()
        {
            misfireInstruction = MisfireInstruction.CalendarIntervalTrigger.DoNothing;
            return this;
        }

        /// <summary>
        /// If the Trigger misfires, use the
        /// <see cref="MisfireInstruction.CalendarIntervalTrigger.FireOnceNow" /> instruction.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>the updated CalendarIntervalScheduleBuilder</returns>
        /// <seealso cref="MisfireInstruction.CalendarIntervalTrigger.FireOnceNow" />
        public CalendarIntervalScheduleBuilder WithMisfireHandlingInstructionFireAndProceed()
        {
            misfireInstruction = MisfireInstruction.CalendarIntervalTrigger.FireOnceNow;
            return this;
        }

        private static void ValidateInterval(int interval)
        {
            if (interval <= 0)
            {
                throw new ArgumentException("Interval must be a positive value.");
            }
        }

        internal CalendarIntervalScheduleBuilder WithMisfireHandlingInstruction(int readMisfireInstructionFromString)
        {
            misfireInstruction = readMisfireInstructionFromString;
            return this;
        }
    }
}